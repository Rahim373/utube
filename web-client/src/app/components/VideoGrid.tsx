"use client";

import LargeVideoCard from "./LargeVideoCard";
import useGridColumnCount from "../hooks/useGridColumnCount";
import { useEffect, useState } from "react";
import { Video } from "../models/Video";
import { ApiRoutes } from "../constants/Api";

export default function VideoGrid() {
  var colCount = useGridColumnCount();
  const [videos, setVideos] = useState<Array<Video>>([]);

  useEffect(() => {
    const fetchData = async () => {
      var response = await fetch(ApiRoutes.Videos);
      var data = await response.json();
      setVideos([...videos, ...data]);
    }

    fetchData().catch(e => console.error(e));
  }, []);

  return (
    <div>
      <div className={`grid grid-cols-${colCount} gap-4`}>
        { videos.map((video, index) => <LargeVideoCard video={video} key={index} />) }
      </div>
    </div>
  );
}
