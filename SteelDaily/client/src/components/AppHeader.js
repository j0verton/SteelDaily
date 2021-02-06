import React, { useState, useContext, useEffect } from "react";
import { Link, useHistory } from "react-router-dom";
import { toast } from "react-toastify";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  NavbarText,
} from "reactstrap";
import { UserProfileContext } from "../providers/UserProfileProvider";
import "./AppHeader.css"
import logo from "../images/steel.svg"


const AppHeader = () => {
  const { getCurrentUser, logout, isAdmin, getToken } = useContext(UserProfileContext);
  const user = getCurrentUser();
  const history = useHistory();
  const [isOpen, setIsOpen] = useState(false);
  const [streak, setStreak] = useState("");

  const toggle = () => setIsOpen(!isOpen);

  const logoutAndReturn = () => {
    return logout().then(() => {
      toast.dark("You are now logged out");
      history.push("/login");
    });
  };

  useEffect(() => {
    console.log("header useeffect")
    getToken().then((token) => {
      return fetch(`/api/streak`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
    }).then(setStreak)

  }, [])
  return (
    <div>
      <Navbar color="dark" dark expand="md">
        <NavbarBrand tag={Link} to="/">
          <img
            id="header-logo"
            src={logo}
            width="40"
            height="40"
            className="mr-1"
            alt="Steel Daily"
          />
        </NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Nav>
          {/* <NavItem>
            <NavLink to="/myprofile" tag={Link}>
              My Profile
                  </NavLink>
          </NavItem>
          <NavItem>
            <NavLink to="/NTIgame" tag={Link}>
              Name That Interval Flash Cards
                  </NavLink>
          </NavItem>
          <NavItem>
            <NavLink to="/NTIFretboardGame" tag={Link}>
              Name That Interval Fretboard
                  </NavLink>
          </NavItem>
          <NavItem>
            <NavLink to="/UnisonFinderGame" tag={Link}>
              Unison Finder
                  </NavLink>
          </NavItem> */}
          <Collapse isOpen={isOpen} navbar>
            <Nav className="mr-auto" navbar>
              {user ? (
                <>
                  <NavItem>
                    <NavLink to="/myprofile" tag={Link}>
                      My Profile
                  </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink to="/NTIgame" tag={Link}>
                      Name That Interval Flash Cards
                  </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink to="/NTIFretboardGame" tag={Link}>
                      Name That Interval Fretboard
                  </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink to="/UnisonFinderGame" tag={Link}>
                      Unison Finder
                  </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink to="/myprofile" tag={Link}>
                      My Profile
                  </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} to="/" onClick={logoutAndReturn}>
                      Logout
                  </NavLink>
                  </NavItem>
                </>
              ) : (
                  <>
                    <NavItem>
                      <NavLink to="/login" tag={Link}>
                        Login
                  </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink to="/register" tag={Link}>
                        Register
                  </NavLink>
                    </NavItem>
                  </>
                )}
            </Nav>
            {user ? (
              <NavbarText className="d-sm-none d-md-block">
                Welcome {user.displayName}
              </NavbarText>
            ) : null}
          </Collapse>
        </Nav>
      </Navbar>
    </div>
  );
};

export default AppHeader;
