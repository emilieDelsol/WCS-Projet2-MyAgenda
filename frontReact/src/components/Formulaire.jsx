import React from "react";
import "./css/Formulaire.css";

class Formulaire extends React.Component {
  state = {
    Rdv: "",
    beginDate: "",
    endDate: "",
    description: "",
    address: "",
    contact: "",
    email: "",
    phone: "",
  };

  handleSubmitForm(event) {
    console.log(this.state);
    event.preventDefault();
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(this.state)
    };
    fetch("http://localhost:54150/appointment", requestOptions);
    alert('You have submitted the form.')  }
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
        <fieldset>
        <legend id="legend">Post an appointment:</legend>

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
          <label>Address</label>
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

        <input type="submit" value="Submit" />
        </fieldset>
      </form>
    );
  }
}
export default Formulaire;
