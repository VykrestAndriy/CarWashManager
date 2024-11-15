namespace CarWashManager.DataAccess.Legacy 
{
    public class NewTransactionSystem
    {
        public void Execute(string washId, decimal washAmount)
        {
            if (string.IsNullOrEmpty(washId) || washAmount <= 0)
            {
                throw new ArgumentException("Invalid wash transaction parameters.");
            }
        }
    }
}
