import React, { useState } from "react";
import "./styles.css";
import AltMenu from "./components/AltMenu";
import Formulaire from "./components/Formulaire";
import FormulaireReact from "./components/FormulaireReact";
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
  const goForm2 = () => {
    setStateOnglets(3);
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
            <div
              onClick={goForm2}
              className={`onglets ${stateOnglets === 3 ? "active" : ""}`}
            >
              <h1>another form</h1>
            </div>
          </div>

          <div className="container">
            {stateOnglets === 1 ? (
              <div className="cont">
                <AltMenu />
                <Switch>
                  <Route exact path="/">
                    <h1>MyAgenda</h1>
                    <p>
                      Application React pour la présentation des requêtes vers
                      l'api MyAgenda
                    </p>
                  </Route>
                  <Route path="/:appointmentCat">
                    <AppointmentsList />
                  </Route>
                </Switch>
              </div>
            ) : stateOnglets === 2 ? (
              <div className="cont">
                <section className="formulaire">
                  <Formulaire />
                </section>
              </div>
            ) : (
              <div className="cont">
                <section className="formulaire">
                  <FormulaireReact />
                </section>
              </div>
            )}
          </div>
        </div>
      </div>
    </Router>
  );
}
