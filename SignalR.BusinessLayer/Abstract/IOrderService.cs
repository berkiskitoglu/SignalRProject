﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TGetTotalOrderCount();
        int TGetActiveOrderCount();
        decimal TGetLastOrderPrice();
        decimal TTodayTotalPrice();

    }
}
