﻿using Hover.Common.Input;
using Hover.Cursor.State;

namespace Hover.Board.State {

	/*================================================================================================*/
	public interface IHoverboardState {

		IHovercursorState HovercursorState { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		ProjectionState GetProjectionState(CursorType pCursorType);

	}

}
