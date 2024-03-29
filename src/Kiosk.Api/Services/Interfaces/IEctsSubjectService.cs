using Kiosk.Abstractions.Models;

namespace KioskAPI.Services.Interfaces;

public interface IEctsSubjectService
{
    Task<bool> AddEctsSubject(EctsSubjectDocument ectsSubjectDocument, CancellationToken cancellationToken);
    
    Task<EctsSubjectResponse> GetSubjectsByMajor(EctsSubjectRequest ectsSubjectRequest, CancellationToken cancellationToken);
}