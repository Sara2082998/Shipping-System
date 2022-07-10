﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using graduaion_project_backed.Dto;
using graduaion_project_backed.Model;
using graduaion_project_backed.Repo;

namespace graduaion_project_backed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        IOrderRepo OrderRepo;
        public OrderController(IOrderRepo OrderRepo)
        {
            this.OrderRepo = OrderRepo;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(OrderRepo.GetAllOrders());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrderById([FromRoute] int id)
        {
            return Ok(OrderRepo.GetById(id));

        }

        [HttpPost]
        public IActionResult Create(Order order1)
        {
            if (ModelState.IsValid == true)
            {
                return Ok(OrderRepo.add(order1));
              
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOrder([FromRoute] int id, [FromBody] Order NewOrder)
        {
            if (ModelState.IsValid)
            {
                OrderRepo.Edit(id, NewOrder);
                return StatusCode(204, "the data Updated");
            }
            return BadRequest("Id Not Valid");

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOnOrder(int id)
        {

            try
            {
                OrderRepo.Delete(id);
                return StatusCode(204, "Record Removed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{statusId:int}")]
        public IActionResult GetByStatus(int statusId, int pageIndex)
        {
            return Ok(OrderRepo.getByStatus(statusId,pageIndex));
        }

        [HttpGet("{statusId:int}")]
        public IActionResult GetByDateAndStatus(DateTime start, DateTime end, int statusId, int pageIndex)
        {
            return Ok(OrderRepo.GetByDateAndStatus(start,end,statusId,pageIndex));
        }





    }
}
