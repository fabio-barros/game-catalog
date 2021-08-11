import { Icon } from "@iconify/react";
import { FC, Fragment } from "react";
import {
    List,
    Datagrid,
    TextField,
    ListProps,
    EditButton,
    Edit,
    SimpleForm,
    TextInput,
    DateInput,
    Create,
    useDataProvider,
    Record,
    SingleFieldList,
    ChipField,
    ArrayField,
    DateField,
    NumberField,
    NumberInput,
    ArrayInput,
    SimpleFormIterator,
    SelectField,
    SelectInput,
    Filter,
    SearchInput,
} from "react-admin";

interface GamesDashboardProps {}

export const GamesList: FC = (props) => {
    return (
        <List {...props}>
            <Datagrid rowClick="edit">
                <TextField label="Id" source="id" />
                <TextField label="Title" source="title" />
                <TextField label="Developer" source="developer" />
                <TextField label="Publisher" source="publisher" />
                <DateField label="Release Date" source="releaseDate" />
                <TextField label="Cover Art URL" source="coverArtUrl" />
                <NumberField label="Price" source="price" />
            </Datagrid>
        </List>
    );
};

export const GamesEdit: FC = (props) => {
    return (
        <Edit {...props}>
            <SimpleForm>
                <TextInput label="Id" source="id" disabled />
                <TextInput label="Title" source="title" />
                <TextInput label="Developer" source="developer" />
                <TextInput label="Publisher" source="publisher" />
                <DateInput label="Release Date" source="releaseDate" />
                <TextInput label="Cover Art URL" source="coverArtUrl" />
                <NumberInput label="Price" source="price" />
            </SimpleForm>
        </Edit>
    );
};

export const GamesCreate: FC = (props) => {
    return (
        <Create title="Register a new Game" {...props}>
            <SimpleForm>
                <TextInput label="Title" source="title" />
                <TextInput label="Developer" source="developer" />
                <TextInput label="Publisher" source="publisher" />
                <DateInput label="Release Date" source="releaseDate" />
                <TextInput label="Cover Art URL" source="coverArtUrl" />
                <NumberInput label="Price" source="price" />
            </SimpleForm>
        </Create>
    );
};

export const EmployeeIcon: FC = () => (
    <Icon icon="dashicons:games" color="#096484" width="30" height="30" />
);
