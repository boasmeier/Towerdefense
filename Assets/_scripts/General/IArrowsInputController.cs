using System;

public interface IArrowsInputController
{
    event Action HandleLeft;
    event Action HandleRight;
    event Action HandleDown;
    event Action HandleUp;
}
