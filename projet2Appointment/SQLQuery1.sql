SELECT RDV AS "Titre",
        BeginDate AS "Heure de début",
        EndDate AS "Heure de fin", 
        AppointmentDescription AS "Description",
        
        Contact,
        Email,
        Phone AS "Téléphone"
FROM Appointment;