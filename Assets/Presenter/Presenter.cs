
public class Presenter
{
    private DomainDataProcessor _dataProcessor;
    private View _view;

    public Presenter(View view)
    {
        _view = view;
        _dataProcessor = new DomainDataProcessor();
        _dataProcessor.FetchDataFromApi(view.InstantiatePieces);
    }
}
