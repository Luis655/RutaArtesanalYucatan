using System.Runtime.InteropServices;
using System;
using AutoMapper;
using QueryApi.Domain.Dtos.Response;
using QueryApi.Domain.Dtos.Requests;
using System.Reflection.Metadata.Ecma335;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;

namespace QueryApi.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Personaartesano, ArtesanoResponse>()
            .ForMember(dest=> dest.Idartesano, opt => opt.MapFrom(src => src.Idartesano))
            .ForMember(dest=> dest.Nombrecompleto, opt=> opt.MapFrom(src=> $"{src.Nombre} {src.Apellidop} {src.Apellidom}"))
            .ForMember(dest=> dest.Nombreasociacion, opt => opt.MapFrom(src => src.IdasociacionNavigation == null ? "N/A": src.IdasociacionNavigation.Nombreasociacion))
            .ForMember(dest=> dest.Statu, opt => opt.MapFrom(src => src.IdloginNavigation.Statu))
            .ForMember(dest=> dest.Nombretaller, opt => opt.MapFrom(src => src.IdtallerNavigation.Nombretaller))
            .ForMember(dest=> dest.Telefonocontacto, opt  => opt.MapFrom(src => src.IdtallerNavigation.Telefonocontacto))
            .ForMember(dest=> dest.Emailcontacto, opt => opt.MapFrom(src => src.IdtallerNavigation.Emailcontacto))
            .ForMember(dest=> dest.Redessociales, opt => opt.MapFrom(src => src.IdtallerNavigation.Redessociales))
            .ForMember(dest=> dest.Latitud, opt => opt.MapFrom(src => src.IdtallerNavigation.Latitud))
            .ForMember(dest=> dest.Longitud, opt => opt.MapFrom(src => src.IdtallerNavigation.Longitud))
            .ForMember(dest=> dest.Tipotaller, opt => opt.MapFrom(src => src.IdtallerNavigation.Tipotaller));
           
            
             CreateMap<ArtesanoCreateRequest, Personaartesano>()
            .ForPath(dest => dest.IdasociacionNavigation.Nombreasociacion, opt => opt.MapFrom(src => src.Nombreasociacion))
            .ForPath(dest => dest.IdloginNavigation.Correo, opt=> opt.MapFrom(src => src.Correo))
            .ForPath(dest => dest.IdloginNavigation.Contraseña, opt=> opt.MapFrom(src => src.Contraseña))
            .ForPath(dest => dest.IdloginNavigation.Statu, opt=> opt.MapFrom(src => src.Statu))
            .ForPath(dest => dest.IdtallerNavigation.Nombretaller, opt=> opt.MapFrom(src => src.Nombretaller))
            .ForPath(dest => dest.IdtallerNavigation.Logodeltaller, opt=> opt.MapFrom(src => src.Logodeltaller))
            .ForPath(dest => dest.IdtallerNavigation.Telefonocontacto, opt=> opt.MapFrom(src => src.Telefonocontacto))
            .ForPath(dest => dest.IdtallerNavigation.Emailcontacto, opt=> opt.MapFrom(src => src.Emailcontacto))
            .ForPath(dest => dest.IdtallerNavigation.Redessociales, opt=> opt.MapFrom(src => src.Redessociales))
            .ForPath(dest => dest.IdtallerNavigation.Latitud, opt=> opt.MapFrom(src => src.Latitud))
            .ForPath(dest => dest.IdtallerNavigation.Longitud, opt=> opt.MapFrom(src => src.Longitud))
            .ForPath(dest => dest.IdtallerNavigation.Longitud, opt=> opt.MapFrom(src => src.Longitud))
            .ForPath(dest=> dest.IdtallerNavigation.Tipotaller, opt => opt.MapFrom(src => src.Tipotaller));;
            
            

            CreateMap<Artesanium, ArtesaniaResponse>()
            .ForMember(dest=> dest.Nombrematerial, opt => opt.MapFrom(src => src.IdmaterialNavigation == null ? "N/A": src.IdmaterialNavigation.Nombrematerial))
            .ForMember(dest=> dest.Descripcionmat, opt => opt.MapFrom(src => src.IdmaterialNavigation == null ? "N/A": src.IdmaterialNavigation.Descripcionmat));

            CreateMap<ArtesaniaCreateRequest, Artesanium>()
            .ForPath(dest => dest.IdmaterialNavigation.Nombrematerial, opt => opt.MapFrom(src => src.Nombrematerial))
            .ForPath(dest => dest.IdmaterialNavigation.Descripcionmat, opt=> opt.MapFrom(src => src.Descripcionmat));



             CreateMap<Restaurante, RestauranteResponse>()
             .ForMember(dest=> dest.Idrestaurante, opt=> opt.MapFrom(src=> src.Idrestaurante))
            .ForMember(dest=> dest.Nombrerest, opt=> opt.MapFrom(src=> src.Nombrerest))
            .ForMember(dest=> dest.Telfonocomercio, opt => opt.MapFrom(src => src.Telfonocomercio == null ? "N/A": src.Telfonocomercio))
            .ForMember(dest=> dest.Descripcionmenu, opt => opt.MapFrom(src => src.Descripcionmenu))
            .ForMember(dest=> dest.Latitud, opt => opt.MapFrom(src => src.Latitud))
            .ForMember(dest=> dest.Longitud, opt  => opt.MapFrom(src => src.Longitud))
            .ForMember(dest=> dest.Tiporestaurante, opt => opt.MapFrom(src => src.Tiporestaurante))
            .ForMember(dest=> dest.Direccion, opt => opt.MapFrom(src => $"{src.IddireccionNavigation.Municipio} {src.IddireccionNavigation.Colonia} {src.IddireccionNavigation.Cruzamientos} {src.IddireccionNavigation.Numero}"))
            .ForMember(dest=> dest.Fotorest, opt => opt.MapFrom(src => src.IdfotomenuNavigation.Fotorest));
           
            
             CreateMap<RestauranteCreateRequest, Restaurante>()
            //.ForPath(dest => dest.Idrestaurante, opt => opt.MapFrom(src => src.Idrestaurante))
            .ForPath(dest => dest.Nombrerest, opt => opt.MapFrom(src => src.Nombrerest))
            .ForPath(dest => dest.Telfonocomercio, opt=> opt.MapFrom(src => src.Telfonocomercio))
            .ForPath(dest => dest.Descripcionmenu, opt=> opt.MapFrom(src => src.Descripcionmenu))
            .ForPath(dest => dest.Latitud, opt=> opt.MapFrom(src => src.Latitud))
            .ForPath(dest => dest.Longitud, opt=> opt.MapFrom(src => src.Longitud))
            .ForPath(dest => dest.Tiporestaurante, opt=> opt.MapFrom(src => src.Tiporestaurante))
            .ForPath(dest => dest.IddireccionNavigation.Municipio, opt=> opt.MapFrom(src => src.Municipio))
            .ForPath(dest => dest.IddireccionNavigation.Colonia, opt=> opt.MapFrom(src => src.Colonia))
            .ForPath(dest => dest.IddireccionNavigation.Cruzamientos, opt=> opt.MapFrom(src => src.Cruzamientos))
            .ForPath(dest => dest.IddireccionNavigation.Numero, opt=> opt.MapFrom(src => src.Numero))
            .ForPath(dest => dest.IdfotomenuNavigation.Fotorest, opt=> opt.MapFrom(src => src.Fotorest));
            

            CreateMap<Rutarestaurantesintermedium, RutaRestauranteResponse>()
            .ForMember(dest=> dest.Rutarestaurantesintermedia, opt=> opt.MapFrom(src=> src.Rutarestaurantesintermedia))
            .ForMember(dest=> dest.Nombreruta, opt=> opt.MapFrom(src=> src.IdrutasrestaurantesNavigation.Nombreruta))
            .ForMember(dest=> dest.Municipio, opt=> opt.MapFrom(src=> src.IdrutasrestaurantesNavigation.Municipio))
            .ForMember(dest=> dest.Latitud, opt => opt.MapFrom(src => src.IdrestauranteNavigation.Latitud))
            .ForMember(dest=> dest.Longitud, opt => opt.MapFrom(src => src.IdrestauranteNavigation.Longitud))
            .ForMember(dest=> dest.Tiporestaurante, opt => opt.MapFrom(src => src.IdrestauranteNavigation.Tiporestaurante));


             CreateMap<Rutatalleresintermedium, RutaTalleresResponse>()
            .ForMember(dest=> dest.Idrutatalleresintermedia, opt=> opt.MapFrom(src=> src.Idrutatalleresintermedia))
            .ForMember(dest=> dest.Nombretaller, opt=> opt.MapFrom(src=> src.IdartesanoNavigation.IdtallerNavigation.Nombretaller))
            .ForMember(dest=> dest.Municipio, opt=> opt.MapFrom(src=> src.IdrutastalleresNavigation.Municipio))
            .ForMember(dest=> dest.Latitud, opt => opt.MapFrom(src => src.IdartesanoNavigation.IdtallerNavigation.Latitud))
            .ForMember(dest=> dest.Longitud, opt => opt.MapFrom(src => src.IdartesanoNavigation.IdtallerNavigation.Longitud));


            
            
        }
    }
}