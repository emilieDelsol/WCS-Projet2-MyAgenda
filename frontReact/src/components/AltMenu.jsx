import React from "react";
import { Link } from "react-router-dom";
import "./altMenuStyle.css";

function AltMenu() {
  return (
    <nav>
      <ul className="altMenu">
        <li>
          <Link to="/">home</Link>
        </li>
        <li>
          <Link to="/all">all</Link>
        </li>
        <li className="deroulant">
          <Link to="/perso">perso</Link>
          <ul class="sous">
            <li>
              <Link to="/perso">tous les perso</Link>
            </li>
            <li>
              <Link to="/persoimportance1">perso et importance faible</Link>
            </li>
            <li>
              <Link to="/persoimportance2">perso et importance moyenne</Link>
            </li>
            <li>
              <Link to="/persoimportance3">perso et importance forte</Link>
            </li>
          </ul>
        </li>
        <li className="deroulant">
          <Link to="/pro">pro</Link>
          <ul class="sous">
            <li>
              <Link to="/pro">tous les rdv pro</Link>
            </li>
            <li>
              <Link to="/proimportance1">pro et importance faible</Link>
            </li>
            <li>
              <Link to="/proimportance2">pro et importance moyenne</Link>
            </li>
            <li>
              <Link to="/proimportance3">pro et importance forte</Link>
            </li>
          </ul>
        </li>
        <li className="deroulant">
          <Link to="">importants</Link>
          <ul class="sous">
            <li>
              <Link to="/importance1">faible</Link>
            </li>
            <li>
              <Link to="/importance2">moyen</Link>
            </li>
            <li>
              <Link to="/importance3">fort</Link>
            </li>
          </ul>
        </li>
      </ul>
    </nav>
  );
}

export default AltMenu;
