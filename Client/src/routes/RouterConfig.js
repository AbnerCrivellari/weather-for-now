import React from 'react'
import { Switch, Route } from 'react-router-dom'
import  Home from "../pages/Home";

export const RouterConfig = () => {
    return (
        <div>
            <Switch>
                <Route exact path={"/"} component={Home} />
                <Route path="*" component={Home}></Route>
            </Switch>
        </div>
    )
}
