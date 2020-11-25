import React from "react";
import "./css/Formulaire.css";

class Formulaire extends React.Component {
  state = {
    AppointmentId: "",
    Rdv: "",
    beginDate: "",
    endDate: "",
    description: "",
    address: "",
    contact: "",
    email: "",
    phone: "",
    importance: false,
    recurrence: false,
    numberOfRecurrence: 0,
    reminder: false,
    pro: false,
    perso: false
  };

  handleSubmitForm(event) {
    console.log(this.state);
    event.preventDefault();
  }
  handleForm = (event) => {
    this.setState({ [event.target.name]: event.target.value });
  };

  render() {
    return (
      <form
        action="http://localhost:54150/appointment/"
        method="post"
        onSubmit={(event) => this.handleSubmitForm(event)}
      >
        <div>
          <label>
            Title :
            <input
              type="text"
              id="rdv"
              name="Rdv"
              onChange={this.handleForm}
              required
            />{" "}
          </label>
        </div>

        <div>
          <label>
            Choose a begin time for your appointment:
            <input
              type="datetime-local"
              name="beginDate"
              id="beginDate"
              placeholder="2020-06-12T19:30"
              min="2018-06-07T00:00"
              max="2050-06-14T00:00"
              onChange={this.handleForm}
              required
            />
          </label>
        </div>

        <div>
          <label>
            Choose a end time for your appointment:
            <input
              type="datetime-local"
              name="endDate"
              id="endDate"
              placeholder="2020-06-12T19:30"
              min="2018-06-07T00:00"
              max="2050-06-14T00:00"
              onChange={this.handleForm}
              required
            />
          </label>
        </div>

        <div>
          <label>
            description
            <textarea
              type="text"
              name="description"
              id="description"
              onChange={this.handleForm}
            />
          </label>
        </div>

        <div>
          <label>Adress</label>
          <input
            type="text"
            name="address"
            id="address"
            onChange={this.handleForm}
          />
        </div>

        <div>
          <label>Contact</label>
          <input
            type="text"
            name="contact"
            id="contact"
            onChange={this.handleForm}
          />
        </div>

        <div>
          <label>Email</label>
          <input
            type="text"
            name="email"
            id="email"
            onChange={this.handleForm}
          />
        </div>

        <div>
          <label>Phone</label>
          <input
            type="text"
            name="phone"
            id="phone"
            onChange={this.handleForm}
          />
        </div>

        <div>
          <label>
            Pro :
            <input
              name="pro"
              id="pro"
              type="checkbox"
              value="false"
              onChange={this.handleForm}
            />
          </label>
        </div>

        <div>
          <label>
            Importance :
            <input
              name="importance"
              id="importance"
              type="number"
              value="true"
              onChange={this.handleForm}
            />
          </label>
        </div>

        <div>
          <label>
            Recurrence :
            <input
              name="recurrence"
              type="checkbox"
              value="true"
              onChange={this.handleForm}
            />
          </label>
          <label>
            every:
            <select onChange={this.handleForm}>
              <option type="number">Year</option>
              <option type="number">Month</option>
              <option type="number">Week</option>
              <option type="number">day</option>
              <option type="number">Hours</option>
            </select>
          </label>
          <label>
            Number of recurrence:
            <input
              name="numberOfRecurrence"
              type="number"
              onChange={this.handleForm}
            />
          </label>
        </div>

        <input type="submit" value="Submit" />
      </form>
    );
  }
}
export default Formulaire;
