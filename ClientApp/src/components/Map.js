import React, { Component } from 'react'
import ReactMapGL, { NavigationControl } from 'react-map-gl'

class Map extends Component {
  constructor(props) {
    super(props)
    this.state = {
      viewport: {
        latitude: 48.864716,
        longitude: 2.349014,
        zoom: 15,
        bearing: 0,
        pitch: 0,
        width: '100%',
        height: '100%'
      }
    }
  }

  updateMap = viewport => {
    this.setState({ viewport })
  }
  render() {
    const { viewport } = this.state
    return (
      <>
        <div id="map" className="map pad2">
          <ReactMapGL
            {...viewport}
            onViewportChange={viewport => this.updateMap(viewport)}
            mapStyle="mapbox://styles/p-polinskmichell/ck1gvw0y94yz91co4qlczvi68"
            mapboxApiAccessToken="pk.eyJ1IjoicC1wb2xpbnNrbWljaGVsbCIsImEiOiJjazFnbm16cGUxNmJzM2VwN2NpcjU3cDlrIn0.F78cmL4ogLFu-zVpet_73A"
          ></ReactMapGL>
        </div>
      </>
    )
  }
}

export default Map
