using HomeWork17_Task1.Model;
using HomeWork17_Task1.Validators;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17_Task1.Controller
{
    public class ClientController
    {
        private readonly IEmailValidator emailValidator;
        private readonly IMobileValidator mobileValidator;
        public ClientController(IEmailValidator emailValidator,IMobileValidator mobileValidator)
        {
            this.emailValidator = emailValidator;
            this.mobileValidator = mobileValidator;
        }

        public Client CreateClient(string name,string email, string mobile)
        {
            Client client = new Client();

            client.Name = name;
            client.Email = email;
            client.Mobile = mobile;

            return client;
        }

        public bool ValidateClient(Client client,out string messenge)
        {
            messenge = "";

            bool isEmailValid = emailValidator.IsValid(client.Email);

            if (!isEmailValid)
            {
                messenge = "Not valid email!";
                return false;
            }

            bool isMobileValid = mobileValidator.IsValid(client.Mobile);

            if (!isMobileValid)
            {
                messenge = "Not valid mobile!";
                return false;
            }

            messenge = "Success!";
            return true;
        }
    }
}
