﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using packt_webapp.Entities;
using packt_webapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace packt_webapp.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        //commentaar
        private ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var allCustomers =_customerRepository.GetAll().ToList();
            var allCustomersDto = allCustomers.Select(x=> Mapper.Map<CustomersDto>(x));//fout oplossen
            return Ok(allCustomersDto);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingleCustomer(Guid id)
        {
            Customer customerFromRepo = _customerRepository.GetSingle(id);
            if (customerFromRepo ==null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<CustomerDto>(customerFromRepo));//fout oplossen
        }

    }
}
