
public interface ISelectableEntity
{
	void OnSelect();
	void OnDeselect();
}

public class SelectionManager
{
	private static SelectionManager s_instance;
	public static SelectionManager Instance
	{ 
		get
		{
			if (s_instance == null) s_instance = new SelectionManager();
			return s_instance;
		}
	}

	ISelectableEntity currentSelectable;
	public ISelectableEntity CurrentSelectable
	{
		get { return currentSelectable; }
		set
		{
			if (currentSelectable != null) currentSelectable.OnDeselect();
			currentSelectable = value;
			if (currentSelectable != null) currentSelectable.OnSelect();
		}
	}
}

