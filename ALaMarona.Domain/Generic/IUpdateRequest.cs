namespace ALaMarona.Domain.Generic
{
    public interface IUpdateRequest<TId> where TId: struct
    {
        TId Id { get; set; }
    }
}
