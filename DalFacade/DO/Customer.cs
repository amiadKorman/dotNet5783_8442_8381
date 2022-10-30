using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public struct Customer
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer email
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Customer address
        /// </summary>
        public string CustomerAdress { get; set; }

        public override string ToString() => $@"
        Customer ID: {ID}, 
        Customer Name: {CustomerName},
        Customer Email: {CustomerEmail},
        Customer Adress: {CustomerAdress}";  
    }

    
}
