﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, string _userId);
        List<Order> GetOrdersFromId();
        void ReturnArt(int artid);


        void DeleteAllOrders();

    }
}
