import { FC, Fragment } from "react";
import {
    Admin,
    Resource,
    Filter,
    SearchInput,
    ListGuesser,
    EditGuesser,
    ShowGuesser,
} from "react-admin";
import restProvider from "ra-data-simple-rest";
import { createBrowserHistory as createHistory } from "history";
import polyglotI18nProvider from "ra-i18n-polyglot";
import { DashboardCard } from "../react-admin/DashboardCard";
import {
    EmployeeIcon,
    GamesCreate,
    GamesEdit,
    GamesList,
} from "../react-admin/GamesDashboard";

interface AdminDashboardProps {}

const history = createHistory();

export const AdminDashboard: FC<AdminDashboardProps> = ({}) => {
    return (
        <Admin
            dataProvider={restProvider("https://localhost:5001/api/v1")}
            dashboard={DashboardCard}
            history={history}
        >
            <Resource
                name="game"
                create={GamesCreate}
                list={GamesList}
                edit={GamesEdit}
                // show={ShowGuesser}
                icon={EmployeeIcon}
            />
            {/* <Resource name="cargos" list={ListGuesser} edit={EditGuesser} show={ShowGuesser}></Resource> */}
        </Admin>
    );
};
