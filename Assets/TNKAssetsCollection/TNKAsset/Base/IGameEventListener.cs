
namespace MyAsset
{

	public interface IListener<T>
	{
		void OnInvoke(T arg);
	}
}