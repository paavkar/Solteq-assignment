import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    entries: [],
};

export const entrySlice = createSlice({
    name: "entry",
    initialState,
    reducers: {
        setEntries: (state, action) => {
            state.entries = action.payload.entries;
        },
    },
});

export type RootState = ReturnType<typeof entrySlice.reducer>

export const { setEntries } = entrySlice.actions;
export default entrySlice.reducer;