﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace projet2Appointment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {

        private static List<Appointment> myList = new List<Appointment>();
        

        [HttpGet]
        
        public List<Appointment> GetList()
        {
            myList.Sort((x, y) => DateTime.Compare(x.BeginDate, y.BeginDate));
            int i = 0;
            foreach (Appointment appointment in myList)
            {
                appointment.Id = i;
                i++;
            }
            return myList;
        }

        [HttpGet("{id}")]

        public List<Appointment> GetFilterPro()
        {
            
            List<Appointment> listFilter = new List<Appointment>();
            foreach (Appointment value in myList)
            {
                if (value.Pro == true)
                {
                    listFilter.Add(value);
                }
                
            }
            
            return listFilter;


        }

        [HttpGet("{id}/perso")]

        public List<Appointment> GetFilterPerso()
        {

            List<Appointment> listFilterPerso = new List<Appointment>();
            foreach (Appointment value in myList)
            {
                if (value.Perso == true)
                {
                    listFilterPerso.Add(value);
                }

            }

            return listFilterPerso;


        }

        [HttpPost]
        public Appointment InsertAppointment(Appointment appointment)
        {
            Appointment myAppointment = new Appointment
            {
                Rdv = appointment.Rdv,
                BeginDate = appointment.BeginDate,
                EndDate = appointment.EndDate,
                Description = appointment.Description,
                Pro = appointment.Pro,
                Perso=appointment.Perso

                
            };

            
            myList.Add(myAppointment);
            return myAppointment;
            
        }

       


        [HttpDelete]
        public List<Appointment> DeleteAppointment(Appointment appointementToDelete)
        {
            myList.RemoveAt(appointementToDelete.Id);
            return myList;
        }
    }

}

