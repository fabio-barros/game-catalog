import { Card, CardContent, CardHeader } from "@material-ui/core";
import { FC, Fragment } from "react";

interface DashboardCardProps {}

export const DashboardCard: FC<DashboardCardProps> = ({}) => {
    return (
        <Card>
            <CardHeader title="Welcome to the administration dashboard" />
            <CardContent>
                At this moment you can only manage the Games database.
            </CardContent>
        </Card>
    );
};
