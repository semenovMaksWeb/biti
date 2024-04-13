CREATE TABLE "users" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "username" varchar NOT NULL,
  "surname" varchar NOT NULL,
  "patronymic" varchar NOT NULL,
  "id_client" integer NOT NULL,
  "password" varchar NOT NULL,
  "email" varchar UNIQUE NOT NULL,
  "date_create" timestamp
);

CREATE TABLE "task" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "thene" varchar NOT NULL,
  "message" text NOT NULL,
  "id_author" integer NOT NULL,
  "id_executor" integer NOT NULL,
  "id_categories" integer NOT NULL,
  "id_status" integer NOT NULL,
  "date_create" timestamp
);

CREATE TABLE "history_task" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "message" text NOT NULL,
  "id_task" integer NOT NULL
);

CREATE TABLE "categoties_task" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "name" varchar NOT NULL,
  "description" varchar
);

CREATE TABLE "status_task" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "name" varchar NOT NULL,
  "description" varchar
);

CREATE TABLE "client" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "name" varchar NOT NULL,
  "description" varchar,
  "address" varchar,
  "phone" varchar
);

CREATE TABLE "right" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "name" varchar NOT NULL,
  "description" varchar
);

CREATE TABLE "token" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "token" varchar UNIQUE NOT NULL,
  "date_create" timestamp,
  "date_end" timestamp
);

CREATE TABLE "users_token" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "id_token" integer UNIQUE NOT NULL,
  "id_users" integer NOT NULL
);

CREATE TABLE "users_right" (
  "id" integer PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
  "id_right" integer UNIQUE NOT NULL,
  "id_users" integer NOT NULL
);

ALTER TABLE "users_token" ADD FOREIGN KEY ("id_users") REFERENCES "users" ("id");

ALTER TABLE "users_token" ADD FOREIGN KEY ("id_token") REFERENCES "token" ("id");

ALTER TABLE "users_right" ADD FOREIGN KEY ("id_users") REFERENCES "users" ("id");

ALTER TABLE "users_right" ADD FOREIGN KEY ("id_right") REFERENCES "right" ("id");

ALTER TABLE "users" ADD FOREIGN KEY ("id_client") REFERENCES "client" ("id");

ALTER TABLE "task" ADD FOREIGN KEY ("id_author") REFERENCES "users" ("id");

ALTER TABLE "task" ADD FOREIGN KEY ("id_executor") REFERENCES "users" ("id");

ALTER TABLE "task" ADD FOREIGN KEY ("id_categories") REFERENCES "categoties_task" ("id");

ALTER TABLE "task" ADD FOREIGN KEY ("id_status") REFERENCES "status_task" ("id");

ALTER TABLE "history_task" ADD FOREIGN KEY ("id_task") REFERENCES "task" ("id");
