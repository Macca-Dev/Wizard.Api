
namespace Estable.Lib.Contracts
{
	public interface IStorageAdapter
	{
		void UploadText(string fileName, string valueToUpload, string containerName);
		string DownloadText(string fileName, string containerName);
	}
}
