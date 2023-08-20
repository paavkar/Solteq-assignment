//import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from "react-redux";

import { Box, Button } from "@mui/material";

import EntryListPage from "./components/EntryListPage"

import { Recording } from "./types"
import { RootState, setEntries } from "./state";

function App() {
    const dispatch = useDispatch();
    const entries = useSelector<RootState, Recording[]>((state) => state.entries)

    const retrieveData = async () => {
        const response = await fetch("https://localhost:7183/api/Consumption")
        const json = await response.json() as Recording[];
        dispatch(setEntries({entries: json}))
    }

    return (
        <div>
            <Box>
                <Box>
                    <Button variant="contained" onClick={() => retrieveData()}>Retrieve Monthly Data</Button>
                </Box>
                {entries.length > 0 ?
                
                    <Box>
                <EntryListPage />
                    </Box>
                : <div></div>
                }
            </Box>
        </div>
    );
}

export default App;