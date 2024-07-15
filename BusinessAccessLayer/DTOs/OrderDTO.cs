﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
	public class OrderDTO
	{
		public int? OrderId { get; set; }
		public int UserId { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItemDTO>? orderItemDTOs { get; set; }

	}
}
