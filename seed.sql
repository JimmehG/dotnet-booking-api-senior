

CREATE TABLE room
(
    id SERIAL NOT NULL PRIMARY KEY,
    code VARCHAR (10)  NOT NULL,
    description  VARCHAR (100)  NOT NULL
);

ALTER TABLE room OWNER TO bookinguser;


CREATE TABLE patient
(
    id SERIAL NOT NULL PRIMARY KEY,
    code VARCHAR (10)  NOT NULL,
    name  VARCHAR (100)  NOT NULL
);

ALTER TABLE patient OWNER TO bookinguser;

CREATE TABLE appointment
(
    booking_number SERIAL NOT NULL PRIMARY KEY,
    room_id INTEGER  NOT NULL,
    patient_id INTEGER  NOT NULL,
    booking_start_date DATE NOT NULL,
    booking_end_date DATE NOT NULL,
    requested_fixed_duration INTEGER,
    requested_extra_duration INTEGER
);

ALTER TABLE appointment OWNER TO bookinguser;

ALTER TABLE appointment ADD CONSTRAINT appointment_room_fk FOREIGN KEY (room_id) REFERENCES room(id);

ALTER TABLE appointment ADD CONSTRAINT appointment_patient_fk FOREIGN KEY (patient_id) REFERENCES patient(id);

INSERT INTO room (code, description)  VALUES ( 'R1','Room R1');
INSERT INTO room (code, description)  VALUES ( 'R2','Room R2');
INSERT INTO room (code, description)  VALUES ( 'R3','Room R3');
INSERT INTO room (code, description)  VALUES ( 'R4','Room R4');
INSERT INTO room (code, description)  VALUES ( 'R5','Room R5');

INSERT INTO patient (code, name) VALUES ('P-A', 'Andrew');
INSERT INTO patient (code, name) VALUES ('P-B', 'Billy');
INSERT INTO patient (code, name) VALUES ('P-C', 'Carla');
INSERT INTO patient (code, name) VALUES ('P-D', 'David');
INSERT INTO patient (code, name) VALUES ('P-E', 'Evan');
INSERT INTO patient (code, name) VALUES ('P-F', 'Felicity');
INSERT INTO patient (code, name) VALUES ('P-G', 'Gareth');
INSERT INTO patient (code, name) VALUES ('P-H', 'Hugh');
INSERT INTO patient (code, name) VALUES ('P-I', 'Isabelle');
INSERT INTO patient (code, name) VALUES ('P-J', 'Jake');
INSERT INTO patient (code, name) VALUES ('P-K', 'Kim');
INSERT INTO patient (code, name) VALUES ('P-L', 'Larry');
INSERT INTO patient (code, name) VALUES ('P-M', 'Melissa');
INSERT INTO patient (code, name) VALUES ('P-N', 'Nora');
INSERT INTO patient (code, name) VALUES ('P-O', 'Opalina');
INSERT INTO patient (code, name) VALUES ('P-P', 'Patricia');
INSERT INTO patient (code, name) VALUES ('P-Q', 'Quintin');
INSERT INTO patient (code, name) VALUES ('P-R', 'Robert');
INSERT INTO patient (code, name) VALUES ('P-S', 'Sally');
INSERT INTO patient (code, name) VALUES ('P-T', 'Tim');
INSERT INTO patient (code, name) VALUES ('P-U', 'Ursula');
INSERT INTO patient (code, name) VALUES ('P-V', 'Veronica');
INSERT INTO patient (code, name) VALUES ('P-W', 'Wally');
INSERT INTO patient (code, name) VALUES ('P-X', 'Xavier');
INSERT INTO patient (code, name) VALUES ('P-Y', 'Yasmine');
INSERT INTO patient (code, name) VALUES ('P-Z', 'Zachary');
