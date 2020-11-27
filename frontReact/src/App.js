import React, { useState } from "react";
import "./styles.css";
import AltMenu from "./components/AltMenu";
import Formulaire from "./components/Formulaire";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

import AppointmentsList from "./components/AppointmentList";

export default function App() {
  const [stateOnglets, setStateOnglets] = useState(1);

  const goListAppointments = () => {
    setStateOnglets(1);
  };

  const goForm = () => {
    setStateOnglets(2);
  };
 
  return (
    <Router>
      <div className="App">
        <div className="contain">
          <div className="contBtn">
            <div
              onClick={goListAppointments}
              className={`onglets ${stateOnglets === 1 ? "active" : ""}`}
            >
              {" "}
              <h1>List of appointments</h1>
            </div>
            <div
              onClick={goForm}
              className={`onglets ${stateOnglets === 2 ? "active" : ""}`}
            >
              <h1>Add an appointment</h1>
            </div>
            
          </div>
          
          <div className="container">
            {stateOnglets === 1 ? (
              <div className="cont">
                <AltMenu />
                <Switch>
                  <Route exact path="/">
                    <h1>MyAgenda</h1>
            
                    <h2 class="center">Search by keyword:</h2>

                    <form action="http://localhost:54150/appointment/searchByWord" method="get" target="blanck" class="getone center">
                      <input type="text" name="wordSearch" id=""/>
                      <input type="submit" value="SUBMIT"/>
                    </form>

                    <h2 class="center">Search between dates:</h2>

                    <form action="http://localhost:54150/appointment/filter/date" method="get" target="blanck" class="getone center">
                      <label>
                        Begin date:
                        <input type="datetime" name="beginDateFilter" id="" placeholder="jj/mm/aaaa hh:mm"/>
                      </label>
                      <label>
                        End date:
                        <input type="datetime" name="endDateFilter" id="" placeholder="jj/mm/aaaa hh:mm"/>
                      </label>
                      <input type="submit" value="SUBMIT"/>
                    </form>
                  </Route>
                  <Route path="/:appointmentCat">
                    <AppointmentsList />
                  </Route>
                </Switch>
              </div>
              ) : (
              <div className="cont">
                <section className="formulaire">
                  <Formulaire />
                </section>
              </div>
            
            )}
          </div>
        </div>
      </div>
    </Router>
  );
}
