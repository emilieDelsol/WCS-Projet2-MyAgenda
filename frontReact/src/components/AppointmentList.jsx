import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

const urls = {
  all: "http://localhost:54150/appointment",
  pro: "http://localhost:54150/appointment/filter/pro",
  perso: "http://localhost:54150/appointment/filter/perso",
  importance1:
    "http://localhost:54150/appointment/filter/importance?importanceFilter=1",
  importance2:
    "http://localhost:54150/appointment/filter/importance?importanceFilter=2",
  importance3:
    "http://localhost:54150/appointment/filter/importance?importanceFilter=3",
  persoimportance1:
    "http://localhost:54150/appointment/filter/perso/importance?importanceFilter=1",
  persoimportance2:
    "http://localhost:54150/appointment/filter/perso/importance?importanceFilter=2",
  persoimportance3:
    "http://localhost:54150/appointment/filter/perso/importance?importanceFilter=3",
  proimportance1:
    "http://localhost:54150/appointment/filter/pro/importance?importanceFilter=1",
  proimportance2:
    "http://localhost:54150/appointment/filter/pro/importance?importanceFilter=2",
  proimportance3:
    "http://localhost:54150/appointment/filter/pro/importance?importanceFilter=3"
};

function AppointmentsList({ url }) {
  const [appointments, setAppointments] = useState();

  const { appointmentCat } = useParams();
  useEffect(() => {
    fetch(urls[appointmentCat])
      .then((response) => response.json())
      .then((data) => setAppointments(data));
  }, [appointmentCat]);
  console.log(appointments);

  //Object.keys(data[0]) ==> tableau avec les clés

  return (
    <div className="cont">
      
      <h2>Appointments list:</h2>
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Title</th>
            <th>Begin date</th>
            <th>End date</th>
            <th>Description</th>
            <th>Address</th>
            <th>Contact</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Priority</th>
          </tr>
        </thead>
        <tbody>
          {appointments &&
            appointments.map((appointment) => (
              <tr>
                <td>{appointment.id}</td>
                <td>{appointment.rdv}</td>
                <td>{appointment.beginDate}</td>
                <td>{appointment.endDate}</td>
                <td>{appointment.description}</td>
                <td>{appointment.address}</td>
                <td>{appointment.contact}</td>
                <td>{appointment.email}</td>
                <td>{appointment.phone}</td>
                <td>{appointment.importance}</td>
              </tr>
            ))}
        </tbody>
      </table>
      
    </div>
  );
}

export default AppointmentsList;
