﻿using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Name = values.Name,
                Subject = values.Subject,
                SendDate = values.SendDate,
                Message = values.Message,
                Email = values.Email
            };
        }
    }
}
