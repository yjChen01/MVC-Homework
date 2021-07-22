namespace MVC_Homework.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static sysdiagramsRepository GetsysdiagramsRepository()
		{
			var repository = new sysdiagramsRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static sysdiagramsRepository GetsysdiagramsRepository(IUnitOfWork unitOfWork)
		{
			var repository = new sysdiagramsRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 作業檢視表01Repository Get作業檢視表01Repository()
		{
			var repository = new 作業檢視表01Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 作業檢視表01Repository Get作業檢視表01Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 作業檢視表01Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶資料Repository Get客戶資料Repository()
		{
			var repository = new 客戶資料Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶資料Repository Get客戶資料Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶資料Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository()
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶聯絡人Repository Get客戶聯絡人Repository()
		{
			var repository = new 客戶聯絡人Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶聯絡人Repository Get客戶聯絡人Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶聯絡人Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}