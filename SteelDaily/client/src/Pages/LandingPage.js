import react, { useContext, useEffect, useState } from "react"
import { Col, Row } from "reactstrap"
import { ActivityFeed } from "../components/ActivityFeed"
import { Leaderboard } from "../components/Leaderboard"
import { StreakContext } from "../providers/StreakProvider"
import { UserProfileContext } from "../providers/UserProfileProvider"

export const LandingPage = () => {
    const { streak } = useContext(StreakContext)
    const { getToken } = useContext(UserProfileContext)
    const [data, setData] = useState({})
    useEffect(() => {
        loadFeedData()

    }, [])

    const loadFeedData = () => {
        return getToken()
            .then(token =>
                fetch(`/api/streak/landingpage`, {
                    method: "GET",
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                })
            ).then(res => res.json())
            .then(res => {
                console.log(res)
                setData(res)
            })
    }
    return (
        <div>
            {/* <Row>
                 <Col sm="12" md={{ size: 6, offset: 3 }}>
                     <h1>Welcome to SteelHead</h1>
                     <h2>Start a daily practice streak by playing one of our games.</h2>
                     <h4>Keep your streak going!  </h4>
                    <h4>Putting a little brain power into memorizing the interval relationships everydayon your instrument will have lasting benefits</h4>
                 </Col>             </Row> */}
            < Row >
                <Col>
                    <ActivityFeed activity={data.resultsForFeed} />
                </Col>
                <Col>
                    <Row><h1>Welcome to SteelHead</h1>
                        <h2>Start a daily practice streak by playing one of our games.</h2>
                        <h4>Keep your streak going!  </h4>
                        <h4>Putting a little brain power into memorizing the interval relationships everydayon your instrument will have lasting benefits</h4>
                    </Row>
                    <Row>
                        <h1>Longest Practice Streaks</h1>
                    </Row>
                    <hr></hr>
                    <Leaderboard leaders={data.leaderStreaks} />
                </Col>
            </Row >
        </div >
    )
}