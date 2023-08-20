import { useSelector } from "react-redux";
import { Box, Table, TableHead, Typography } from "@mui/material";

import { Recording, Month } from "../../types";
import { TableCell } from "@mui/material";
import { TableRow } from "@mui/material";
import { TableBody } from "@mui/material";

import { RootState } from "../../state";


const EntryListPage = () => {
    const entries = useSelector<RootState, Recording[]>((state) => state.entries)

    return (
        <div className="App">
            <Box>
                <Typography align="center" variant="h6">
                    Electricity consumption by month
                </Typography>
            </Box>
            <Table style={{ marginBottom: "1em" }}>
                <TableHead>
                    <TableRow>
                        <TableCell>Location</TableCell>
                        <TableCell>Month</TableCell>
                        <TableCell>Consumption</TableCell>
                        <TableCell>Unit</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {Object.values(entries).map((entry: Recording) => (
                        <TableRow key={entry.month}>
                            <TableCell>{entry.location}</TableCell>
                            <TableCell>{Month[entry.month]}</TableCell>
                            <TableCell>{entry.value}</TableCell>
                            <TableCell>{entry.unit}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>
    );
};

export default EntryListPage;