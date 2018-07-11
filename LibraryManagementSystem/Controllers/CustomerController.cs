﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Data.Model;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();
            var customers = _customerRepository.GetAll();

            if (customers == null || !customers.Any())
            {
                return View("Empty!");
            }

            foreach (var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Count(x => x.CustomerId == customer.CustomerId)
                });
            }

            return View(customerVM);
        }
    }
}