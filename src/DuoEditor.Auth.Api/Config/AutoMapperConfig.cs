using AutoMapper;
using DuoEditor.Auth.Api.Presenters;
using DuoEditor.Auth.Domain.Entities;

namespace hr.API.Config
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig()
    {
      CreateMap<User, UserPresenter>();
      CreateMap<User, AuthUserPresenter>();
    }
  }
}