﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Dtos;
using Template.Business.Interfaces;
using Template.Business.Models;
using Template.Business.Models.MultiTenancy;
using Template.Identity.Exensions;

namespace Template.Api.Controllers
{
    [Authorize]
    [Route("api/{tenant}/[controller]")]
    [ApiController]
    public class ExampleController : MainController
    {
        private readonly IExampleRepository _exempleRepository;
        private readonly IExampleService _exempleService;
        private readonly IMapper _mapper;
        private readonly Tenant _tenant;

        public ExampleController(IExampleRepository exemplerepository, IExampleService exempleSrevice, IMapper mapper, INotificator notificator, Tenant tenant, IUser user) : base(notificator, user)
        {
            _exempleRepository = exemplerepository;
            _exempleService = exempleSrevice;
            _mapper = mapper;
            _tenant = tenant;
        }

        [HttpGet("{id:guid}")]
        public async Task<ExampleDto> ObterPorId(Guid Id)
        {
            return _mapper.Map<ExampleDto>(await _exempleRepository.ObterPorId(Id));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(_tenant);//_mapper.Map<IEnumerable<ExampleDto>>(await _exempleRepository.ObterTodos());
        }
        [HttpPost]
        public async Task<ActionResult<ExampleDto>> Adicionar(ExampleDto exempleDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _exempleService.Adicionar(_mapper.Map<Example>(exempleDto));

            return CustomResponse(exempleDto);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ExampleDto>> Atualizar(Guid id, ExampleDto exempleDto)
        {
            if (id != exempleDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na consulta");
                return CustomResponse(exempleDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _exempleService.Atualizar(_mapper.Map<Example>(exempleDto));

            return CustomResponse(exempleDto);
        }
        [ClaimsAuthorize("Administrador", "Administrador")]
        [HttpDelete("{id:guid}")]
        public async Task Remover(Guid id)
        {
            await _exempleRepository.Remover(id);
        }


    }
}