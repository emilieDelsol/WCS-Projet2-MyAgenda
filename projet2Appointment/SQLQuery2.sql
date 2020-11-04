USE MyAgenda
INSERT INTO Appointment (Rdv, BeginDate, EndDate, AppointmentDescription, Contact, Email, Phone, Importance, Recurence,        Reminder,Pro,Perso)
VALUES ('My first RDV', '2020-08-08T16:00:00', '2020-08-08T16:15:00', 'This is my first RDV', 'Monsieur Moudenc', 'moudenc@mairie-toulouse.fr', '0601234567', '1', 'false', 'false','false','true'),
                ('RDV Kiné', '2020-10-30T14:00:00', '2020-10-30T16:15:00', 'RDV chez le kiné', 'Clinique de l''Union 31240 Saint Jean', 'Gaetan Machin', 'clinique-union@ramsey.fr', '0501234567', '2', 'true', 'true','false','true'),
                ('Réunion parent-prof', '2020-11-10T17:00:00', '2020-11-10T18:00:00', 'Réunion pour le petit Colas', 'Ecole des cancres 31140 Montberon', 'Madame la CPE','','051234567', '2', 'false', 'true')