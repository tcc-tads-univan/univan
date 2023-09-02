﻿using Mapster;
using Univan.Api.Contracts.Driver;
using Univan.Application.Contracts.Driver;
using Univan.Application.Services.Driver.Command.CreateDriver;

namespace Univan.Api.MapperConfiguration
{
    public class StudentMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateDriverRequest, CreateDriverCommand>()
                .ConstructUsing(src => new CreateDriverCommand(UtilMapper.FormatCnh(src.Cnh),
                src.Name,
                src.Email,
                src.Password,
                UtilMapper.FormatCpf(src.Cpf),
                UtilMapper.CleanPhone(src.PhoneNumber),
                src.Birthday,
                UtilMapper.GetPictureValue(src.ProfilePicture)));

            config.NewConfig<DriverResult, DriverResponse>();
        }

    }
}