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
          <Link to="/perso">personal</Link>
          <ul class="sous">
            <li>
              <Link to="/perso">all personal appointments</Link>
            </li>
            <li>
              <Link to="/persoimportance1">personal and low priority</Link>
            </li>
            <li>
              <Link to="/persoimportance2">personal and medium priority</Link>
            </li>
            <li>
              <Link to="/persoimportance3">personal and high priority</Link>
            </li>
          </ul>
        </li>
        <li className="deroulant">
          <Link to="/pro">professional</Link>
          <ul class="sous">
            <li>
              <Link to="/pro">all professional appointments</Link>
            </li>
            <li>
              <Link to="/proimportance1">professional and low priority</Link>
            </li>
            <li>
              <Link to="/proimportance2">professional and medium priority</Link>
            </li>
            <li>
              <Link to="/proimportance3">professional and high priority</Link>
            </li>
          </ul>
        </li>
        <li className="deroulant">
          <Link>priority</Link>
          <ul class="sous">
            <li>
              <Link to="/importance1">low</Link>
            </li>
            <li>
              <Link to="/importance2">medium</Link>
            </li>
            <li>
              <Link to="/importance3">high</Link>
            </li>
          </ul>
        </li>
      </ul>
    </nav>
  );
}

export default AltMenu;
