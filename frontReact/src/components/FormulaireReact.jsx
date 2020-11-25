import React, { useState } from "react";
import axios from "axios";

const Formulaire = () => {
  const [rdv, setRdv] = useState("");
  const [beginDate, setBeginDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [description, setDescription] = useState("");
  const [address, setAdress] = useState("");
  const [contact, setContact] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [importance, setImportance] = useState("");
  const [recurrence, setRecurrence] = useState("");
  const [frequence, setFrequence] = useState("");
  const [numberOfRecurrence, setNumberOfRecurrence] = useState("");
  const [pro, setPro] = useState("");

  /* generic onChange function that allows to capture the id
   */
  const onChange = (e) => {
    let eventId = e.currentTarget.id;
    let eventValue = e.currentTarget.value;
    // cases handle
    switch (eventId) {
      case "rdv":
        setRdv(eventValue);
        break;
      case "beginDate":
        setBeginDate(eventValue);
        break;
      case "endDate":
        setEndDate(eventValue);
        break;
      case "description":
        setDescription(eventValue);
        break;
      case "address":
        setAdress(eventValue);
        break;
      case "contact":
        setContact(eventValue);
        break;
      case "email":
        setEmail(eventValue);
        break;
      case "phone":
        setPhone(eventValue);
        break;
      case "importance":
        setImportance(eventValue);
        break;
      case "recurrence":
        setRecurrence(eventValue);
        break;
      case "frequence":
        setFrequence(eventValue);
        break;
      case "numberOfRecurrence":
        setNumberOfRecurrence(eventValue);
        break;
      case "pro":
        setPro(eventValue);
        break;
      // errors handle
      default:
        console.log(`An error occured on ${eventId} input`);
    }
  };
  const config = {
    url: "http://localhost:54150/appointment",
    method: "POST",
    headers: {
      "Content-Type": "application/json;charset=UTF-8"
    },
    data: {
      rdv: rdv,
      beginDate: beginDate,
      endDate: endDate,
      description: description,
      address: address,
      contact: contact,
      email: email,
      phone: phone,
      importance: importance,
      recurrence: recurrence,
      frequence: frequence,
      numberOfRecurrence: numberOfRecurrence,
      pro: pro
    }
  };

  const onSubmit = (e) => {
    e.preventDefault();
    // axios request passing config
    axios(config)
      .then((res) => res.data)
      .then((res) => {
        alert(`Movie ${rdv} has been sent!`);
      })
      .catch((error) => {
        alert("Oups ... an error occured :(");
      });
  };

  return (
    <>
      <form id="form" onSubmit={onSubmit}>
        <fieldset>
          <legend id="legend">Post an appointment:</legend>
          <div>
            <label htmlFor="rdv">
              Title :
              <input
                type="text"
                id="rdv"
                name="rdv"
                value={rdv}
                onChange={onChange}
                required
              />{" "}
            </label>
          </div>

          <div>
            <label htmlFor="beginDate">
              Choose a begin time for your appointment:
              <input
                type="datetime-local"
                name="beginDate"
                placeholder="2020-06-12T19:30"
                min="2018-06-07T00:00"
                max="2050-06-14T00:00"
                onChange={onChange}
              />
            </label>
          </div>

          <div>
            <label htmlFor="endDate">
              Choose a end time for your appointment:
              <input
                type="datetime-local"
                id="description"
                name="endDate"
                placeholder="2020-06-12T19:30"
                min="2018-06-07T00:00"
                max="2050-06-14T00:00"
                onChange={onChange}
              />
            </label>
          </div>

          <div>
            <label htmlFor="description">
              description
              <textarea
                type="text"
                id="description"
                name="description"
                value={description}
                onChange={onChange}
              />
            </label>
          </div>

          <div>
            <label htmlFor="address">Adress</label>
            <input
              type="text"
              name="address"
              id="address"
              value={address}
              onChange={onChange}
            />
          </div>

          <div>
            <label htmlFor="contact">Contact</label>
            <input
              type="text"
              id="contact"
              name="contact"
              value={contact}
              onChange={onChange}
            />
          </div>

          <div>
            <label htmlFor="email">Email</label>
            <input
              type="text"
              id="email"
              name="email"
              value={email}
              onChange={onChange}
            />
          </div>

          <div>
            <label htmlFor="phone">Phone</label>
            <input
              type="text"
              id="phone"
              name="phone"
              value={phone}
              onChange={onChange}
            />
          </div>

          <div>
            <label htmlFor="pro">
              Pro :
              <input
                name="pro"
                id="pro"
                type="checkbox"
                value={pro}
                onChange={onChange}
              />
            </label>
          </div>

          <div>
            <label htmlFor="importance">
              Importance :
              <input
                name="importance"
                id="importance"
                type="number"
                value={importance}
                onChange={onChange}
              />
            </label>
          </div>

          <div>
            <label htmlFor="recurrence">
              Recurrence :
              <input
                name="recurrence"
                id="recurrence"
                type="checkbox"
                value={recurrence}
                onChange={onChange}
              />
            </label>
            <label htmlFor="frequence">
              every:
              <select onChange={onChange}>
                <option value="1">Year</option>
                <option value="2">Month</option>
                <option value="3">Week</option>
                <option value="4">day</option>
                <option value="5">Hours</option>
              </select>
            </label>
            <label htmlFor="numberOfRecurrence">
              Number of recurrence:
              <input
                id="numberOfRecurrence"
                name="numberOfRecurrence"
                type="number"
                value={numberOfRecurrence}
                onChange={onChange}
              />
            </label>
          </div>
          <button type="submit" value="send">
            Send
          </button>
        </fieldset>
      </form>
    </>
  );
};
export default Formulaire;
