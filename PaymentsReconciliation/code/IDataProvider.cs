namespace PaymentsReconciliation
{
    public interface IDataProvider
    {
        void LoadData(IUnitOfWork unitOfWork);
    }
}
