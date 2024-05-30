﻿using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppRoleInterfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		
		private readonly IAppUserRepository _appUserRepository;
		private readonly IAppRoleRepository _appRoleRepository;

		public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository)
		{
			_appUserRepository = appUserRepository;
			_appRoleRepository = appRoleRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserRepository.GetByFilterAsync(x=>x.Username==request.Username && x.Password == request.Password);

			if(user != null)
			{
				values.IsExist = true;
				values.Username = user.Username;
				values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
				values.Id = user.AppUserId;
			}
			return values;

		}
	}
}
