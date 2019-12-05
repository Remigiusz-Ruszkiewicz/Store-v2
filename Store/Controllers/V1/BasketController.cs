using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Contracts.V1;
using Store.Contracts.V1.Requests;
using Store.Contracts.V1.Responses;
using Store.Models;
using Store.Services;

namespace Store.Controllers.V1
{
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public BasketController(IBasketService basketService, IUsersService usersService,IMapper mapper)
        {
            this.basketService = basketService;
            this.usersService = usersService;
            this.mapper = mapper;
        }
        
        [HttpPost(ApiRoutes.Basket.Add)]
        public async Task<IActionResult> Add([FromBody]NewBaskedItemRequest newBaskedItemRequest)
        {
            var newBasket = mapper.Map<Basket>(newBaskedItemRequest);
            var Basket = await basketService.AddAsync(newBasket);
            return Ok(Basket);
        }
        [HttpGet(ApiRoutes.Basket.Get)]
        public async Task<IActionResult> Get()
        {
            var basket = await basketService.GetAsync();
            if (basket == null)
            {
                return NotFound();
            }
            var response = mapper.Map<ICollection<BasketResponse>>(basket);
            return Ok(response);
        }
        [HttpDelete(ApiRoutes.Basket.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            var basket = await basketService.DeleteAsync(Id);
            var response = mapper.Map<ICollection<BasketResponse>>(basket);
            return Ok(response);
        }
    }
}