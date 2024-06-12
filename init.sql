CREATE TABLE devices
(
   id               SERIAL PRIMARY KEY,
   name             TEXT,
   calibration_info TEXT,
   manufacturer     TEXT,
   model            TEXT
);

CREATE TABLE measurements
(
   id                   SERIAL PRIMARY KEY,
   measurement_at       TIMESTAMP,
   device_id            INT REFERENCES devices (id),
   gamma_spectrum       TEXT,
   area_line_id         INT REFERENCES area_lines (id) ON DELETE CASCADE
);

CREATE TABLE customers
(
   id    SERIAL PRIMARY KEY,
   name  TEXT,
   phone VARCHAR(20),
   email TEXT
);

CREATE TABLE projects
(
   id          SERIAL PRIMARY KEY,
   name        TEXT,
   customer_id INT REFERENCES customers (id),
   start_date  DATE,
   end_date    DATE
);

CREATE TABLE areas
(
   id          SERIAL PRIMARY KEY,
   name        TEXT,
   top_left_lat  DOUBLE PRECISION,
   top_left_lon  DOUBLE PRECISION,
   top_right_lat  DOUBLE PRECISION,
   top_right_lon  DOUBLE PRECISION,
   bottom_left_lat  DOUBLE PRECISION,
   bottom_left_lon  DOUBLE PRECISION,
   bottom_right_lat  DOUBLE PRECISION,
   bottom_right_lon  DOUBLE PRECISION
);

CREATE TABLE area_lines
(
   id          SERIAL PRIMARY KEY,
   name        TEXT,
   top_left_lat  DOUBLE PRECISION,
   top_left_lon  DOUBLE PRECISION,
   top_right_lat  DOUBLE PRECISION,
   top_right_lon  DOUBLE PRECISION,
   bottom_left_lat  DOUBLE PRECISION,
   bottom_left_lon  DOUBLE PRECISION,
   bottom_right_lat  DOUBLE PRECISION,
   bottom_right_lon  DOUBLE PRECISION
);

CREATE TABLE project_areas
(
   project_id INT REFERENCES projects (id) ON DELETE CASCADE,
   area_id    INT REFERENCES areas (id) ON DELETE CASCADE,
   PRIMARY KEY (project_id, area_id)
);

CREATE TABLE area_lines_areas
(
   area_id      INT REFERENCES areas (id) ON DELETE CASCADE,
   area_line_id INT REFERENCES area_lines (id) ON DELETE CASCADE,
   PRIMARY KEY (area_id, area_line_id)
);

CREATE TYPE user_role AS ENUM ('Геофизик', 'Инженер', 'Администратор');

CREATE TABLE users
(
   id           SERIAL PRIMARY KEY,
   email        TEXT,
   password     TEXT,
   phone_number VARCHAR(20),
   role         user_role DEFAULT 'Инженер'
);
