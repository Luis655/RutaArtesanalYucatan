using System;
using QueryApi.Domain.Dtos.Requests;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;

namespace QueryApi.Application.Services
{

    public class ArtesaniaService
    {
        public static bool ValidationUpdate(ArtesaniaCreateRequest artesanium)
        {
            if(artesanium.Idartesania<=0)
                return false;
            if(string.IsNullOrEmpty(artesanium.Nombreartesania))
                return false;
            return true;
        }
    }
}