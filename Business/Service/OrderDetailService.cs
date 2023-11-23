using Data.Repository;
using Models;
using Presentation.DTOs;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class OrderDetailService : IOrderDetailService
{
    private readonly IMapper _mapper;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailService(IMapper mapper, IOrderDetailRepository orderDetailRepository)
    {
        _mapper = mapper;
        _orderDetailRepository = orderDetailRepository;
    }

    public OrderDetailDto GetOrderDetailById(Guid id)
    {
        var orderDetail = _orderDetailRepository.GetOrderDetailById(id);
        return _mapper.Map<OrderDetailDto>(orderDetail);
    }

    public List<OrderDetailDto> GetAllOrderDetails()
    {
        var orderDetails = _orderDetailRepository.GetAllOrderDetails();
        return _mapper.Map<List<OrderDetailDto>>(orderDetails);
    }

    public void AddOrderDetail(OrderDetailDto orderDetailDto)
    {
        var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
        _orderDetailRepository.AddOrderDetail(orderDetail);
    }

    public void UpdateOrderDetail(OrderDetailDto orderDetailDto)
    {
        var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
        _orderDetailRepository.UpdateOrderDetail(orderDetail);
    }

    public void DeleteOrderDetail(Guid id)
    {
        _orderDetailRepository.DeleteOrderDetail(id);
    }
}
