"use client";

import LargeVideoCard from "./LargeVideoCard";
import useGridColumnCount from "../hooks/useGridColumnCount";
import { useCallback, useEffect, useState } from "react";
import { Video } from "../models/Video";
import { ApiRoutes } from "../constants/Api";
import { useSession } from "next-auth/react";

export default function VideoGrid() {
  var colCount = useGridColumnCount();
  const [videos, setVideos] = useState<Array<Video>>([]);
  const { data: session } = useSession();

  useEffect(() => {
    const fetchData = async () => {
      var response = await fetch(ApiRoutes.Videos);
      var data = await response.json();
      setVideos([...videos, ...data]);
    };

    fetchData().catch((e) => console.error(e));
  }, []);

  return (
    <div>
      <div className={`grid grid-cols-${colCount} gap-4`}>
        {videos.map((video, index) => (
          <LargeVideoCard video={video} key={index} />
        ))}
      </div>
    </div>
  );
}
