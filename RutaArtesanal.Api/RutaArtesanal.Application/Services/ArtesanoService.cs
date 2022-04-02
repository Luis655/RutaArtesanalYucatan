using QueryApi.Domain.Dtos.Requests;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;

namespace QueryApi.Application.Services
{

    public class ArtesanoService
    {
        public static bool ValidationUpdate(ArtesanoCreateRequest personaartesano)
        {
            if(personaartesano.Idartesano<=0)
                return false;
            if(string.IsNullOrEmpty(personaartesano.Nombre))
                return false;
            return true;
        }
    }
}