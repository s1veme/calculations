using dotenv.net.Utilities;
using dotenv.net;
using System.Diagnostics;
using GeoApp.Infrastructure;
using System.IO;
using GeoApp.Infrastructure.Repositories;
using GeoApp.Infrastructure.Repositories.Project;
using GeoApp.Application.Project;
using GeoApp.Infrastructure.Repositories.Device;
using GeoApp.Application.Device;
using GeoApp.Infrastructure.Repositories.Area;
using GeoApp.Application.Area;
using GeoApp.Infrastructure.Repositories.AreaLine;
using GeoApp.Application.AreaLine;

namespace GeoApp
{

    public partial class App : System.Windows.Application
    {
        public App()
        {
            var pathEnv = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, ".env");

            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { pathEnv }));

            DotEnv.Read();

            var envVars = DotEnv.Read();

            Debug.WriteLine(envVars);
            string host = EnvReader.GetStringValue("POSTGRES_HOST");
            int port = EnvReader.GetIntValue("POSTGRES_PORT");
            string username = EnvReader.GetStringValue("POSTGRES_USER");
            string password = EnvReader.GetStringValue("POSTGRES_PASSWORD");
            string database = EnvReader.GetStringValue("POSTGRES_DB");

            var db = new Database(host, port, username, password, database);

            var userRepository = new UserRepository(db);
            new UserService(userRepository);

            var projectRepository = new ProjectRepository(db);
            new ProjectService(projectRepository);

            var deviceRepository = new DeviceRepository(db);
            new DeviceService(deviceRepository);

            var areaRepository = new AreaRepository(db);
            new AreaService(areaRepository);

            var areaLineRepository = new AreaLineRepository(db);
            new AreaLineService(areaLineRepository);
        }
    }
}
